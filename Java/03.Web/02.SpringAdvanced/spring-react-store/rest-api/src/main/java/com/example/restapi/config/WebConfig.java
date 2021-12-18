package com.example.restapi.config;

import com.example.restapi.web.interceptors.AdminInterceptor;
import com.example.restapi.web.interceptors.AuthenticateInterceptor;
import com.example.restapi.web.interceptors.AlterRequestInterceptor;
import org.springframework.stereotype.Component;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Component
public class WebConfig implements WebMvcConfigurer {
    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        registry.addInterceptor(new AuthenticateInterceptor())
                .addPathPatterns("/authenticate");
        registry.addInterceptor(new AdminInterceptor())
                .addPathPatterns("/users/all");
        registry.addInterceptor(new AlterRequestInterceptor());
    }
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        registry.addMapping("/**").allowedMethods("GET", "PUT", "POST", "DELETE", "OPTIONS", "PATCH");
    }
}
