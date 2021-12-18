package com.java.exam.web;

import com.java.exam.model.binding.AddShipBindingModel;
import com.java.exam.model.service.ShipServiceModel;
import com.java.exam.service.ShipService;
import com.java.exam.util.CurrentUser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.validation.Valid;

@Controller
@RequestMapping("/ships")
public class ShipController {
    private final ShipService shipService;
    private final ModelMapper modelMapper;
    private final CurrentUser currentUser;

    public ShipController(ShipService shipService, ModelMapper modelMapper, CurrentUser currentUser) {
        this.shipService = shipService;
        this.modelMapper = modelMapper;
        this.currentUser = currentUser;
    }

    @ModelAttribute
    public AddShipBindingModel addShipBindingModel() {
        return new AddShipBindingModel();
    }
    @GetMapping("/add")
    public String add(){
        if (!currentUser.LoggedIn()) {
            return "redirect:/";
        }
        return "ship-add";
    }

    @PostMapping("/add")
    public String addShipConfirm(@Valid AddShipBindingModel addShipBindingModel,
                                  BindingResult bindingResult, RedirectAttributes redirectAttributes) {
        if (bindingResult.hasErrors()) {
            redirectAttributes
                    .addFlashAttribute("addShipBindingModel", addShipBindingModel)
                    .addFlashAttribute("org.springframework.validation.BindingResult.addShipBindingModel", bindingResult);

            return "redirect:add";
        }

        shipService.addShip(modelMapper.map(addShipBindingModel, ShipServiceModel.class));

        return "redirect:/";
    }
}
