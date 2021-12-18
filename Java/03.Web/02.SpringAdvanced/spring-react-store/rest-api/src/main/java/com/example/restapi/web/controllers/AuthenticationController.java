package com.example.restapi.web.controllers;

import com.example.restapi.config.JwtTokenUtil;
import com.example.restapi.constants.Logging;
import com.example.restapi.constants.RolesData;
import com.example.restapi.constants.UserMessages;
import com.example.restapi.model.response.UserResponse;
import com.example.restapi.model.response.impl.UserAuthResponseModel;
import com.example.restapi.model.response.impl.UserVerifyResponseModel;
import com.example.restapi.model.security.JwtRequest;
import com.example.restapi.model.service.UserServiceModel;
import com.example.restapi.service.UserService;
import com.example.restapi.util.JSONResponse;
import org.modelmapper.ModelMapper;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@CrossOrigin
public class AuthenticationController {
    private static final String AUTHORIZATION_HEADER = "Authorization";
    private static final String AUTHORIZATION_PREFIX = "Bearer";
    private final Logger logger = LoggerFactory.getLogger(AuthenticationController.class);

    private final AuthenticationManager authenticationManager;
    private final JwtTokenUtil jwtTokenUtil;
    private final UserService userService;
    private final ModelMapper modelMapper;

    public AuthenticationController(AuthenticationManager authenticationManager, JwtTokenUtil jwtTokenUtil, UserService userService, ModelMapper modelMapper) {
        this.authenticationManager = authenticationManager;
        this.jwtTokenUtil = jwtTokenUtil;
        this.userService = userService;
        this.modelMapper = modelMapper;
    }

    @RequestMapping(value = "/authenticate", method = RequestMethod.POST,
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<?> createAuthenticationToken(@RequestBody JwtRequest authenticationRequest) {
        var responseError = authenticate(authenticationRequest.getUsername(), authenticationRequest.getPassword());
        if (responseError != null) {
            return responseError;
        }

        final UserDetails userDetails = userService
                .loadUserByUsername(authenticationRequest.getUsername());

        final String token = jwtTokenUtil.generateToken(userDetails);
        UserServiceModel userServiceModel = userService.getByUsername(userDetails.getUsername());

        UserAuthResponseModel userAuthResponseModel = modelMapper.map(userServiceModel, UserAuthResponseModel.class);
        populateUserResponseFields(userDetails, userAuthResponseModel);
        userAuthResponseModel.setToken(token);

        logger.info(Logging.TRACE_AUTHENTICATE_MESSAGE + userServiceModel.getUsername());
        return ResponseEntity.ok(userAuthResponseModel);
    }

    @GetMapping(value = "/verify",
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<?> verifyAuthenticationToken(@RequestHeader(AUTHORIZATION_HEADER) String bearerToken,
                                                       Authentication authentication) {
        if (bearerToken == null || !bearerToken.startsWith(AUTHORIZATION_PREFIX)) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(JSONResponse.jsonFromString(UserMessages.INVALID_JWT));
        }

        Object principalObj = authentication.getPrincipal();
        if (principalObj == null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(JSONResponse.jsonFromString(UserMessages.EMPTY_PRINCIPAL));
        }

        final UserDetails userDetails = (UserDetails) principalObj;
        UserServiceModel userServiceModel = userService.getByUsername(userDetails.getUsername());

        UserVerifyResponseModel userVerifyResponseModel = modelMapper.map(userServiceModel, UserVerifyResponseModel.class);
        populateUserResponseFields(userDetails, userVerifyResponseModel);

        return ResponseEntity.ok(userVerifyResponseModel);
    }

    private ResponseEntity<?> authenticate(String username, String password) {
        try {
            authenticationManager
                    .authenticate(new UsernamePasswordAuthenticationToken(username, password));

            return null;
        } catch (DisabledException e) {
            logger.warn(Logging.TRACE_AUTHENTICATE_DISABLED_ERROR);
            return ResponseEntity.status(HttpStatus.FORBIDDEN).body(JSONResponse.jsonFromString(UserMessages.ACCOUNT_INACTIVE));
        } catch (BadCredentialsException e) {
            logger.warn(Logging.TRACE_AUTHENTICATE_INVALID_CREDENTIALS_ERROR);
            return ResponseEntity.status(HttpStatus.FORBIDDEN).body(JSONResponse.jsonFromString(UserMessages.INVALID_CREDENTIALS));
        }
    }

    private void populateUserResponseFields(UserDetails userDetails, UserResponse userResponse) {
        userResponse.setRoot(userDetails.getAuthorities().contains(new SimpleGrantedAuthority(RolesData.ROLE_ROOT)));
        userResponse.setAdministrator(userDetails.getAuthorities().contains(new SimpleGrantedAuthority(RolesData.ROLE_ADMIN)));
        userResponse
                .setActive(userDetails.isAccountNonExpired() && userDetails.isEnabled() && userDetails.isAccountNonLocked());
    }
}
