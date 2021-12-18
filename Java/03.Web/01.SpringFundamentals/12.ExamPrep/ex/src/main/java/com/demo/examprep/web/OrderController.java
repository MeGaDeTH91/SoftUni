package com.demo.examprep.web;

import com.demo.examprep.model.binding.AddOrderBindingModel;
import com.demo.examprep.model.service.OrderServiceModel;
import com.demo.examprep.service.OrderService;
import com.demo.examprep.util.CurrentUser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.validation.Valid;

@Controller
@RequestMapping("/orders")
public class OrderController {
    private final OrderService orderService;
    private final ModelMapper modelMapper;
    private final CurrentUser currentUser;

    public OrderController(OrderService orderService, ModelMapper modelMapper, CurrentUser currentUser) {
        this.orderService = orderService;
        this.modelMapper = modelMapper;
        this.currentUser = currentUser;
    }

    @ModelAttribute
    public AddOrderBindingModel addOrderBindingModel() {
        return new AddOrderBindingModel();
    }
    @GetMapping("/add")
    public String add(){
        if (!currentUser.LoggedIn()) {
            return "redirect:/";
        }
        return "order-add";
    }

    @PostMapping("/add")
    public String addOrderConfirm(@Valid AddOrderBindingModel addOrderBindingModel,
                                  BindingResult bindingResult, RedirectAttributes redirectAttributes) {
        if (bindingResult.hasErrors()) {
            redirectAttributes
                    .addFlashAttribute("addOrderBindingModel", addOrderBindingModel)
                    .addFlashAttribute("org.springframework.validation.BindingResult.addOrderBindingModel", bindingResult);

            return "redirect:add";
        }

        orderService.addOrder(modelMapper.map(addOrderBindingModel, OrderServiceModel.class));

        return "redirect:/";
    }

    @GetMapping("/ready/{id}")
    public String ready(@PathVariable Long id){
        if (currentUser.LoggedIn()) {
            orderService.readyOrder(id);
        }
        return "redirect:/";
    }
}
