package com.demo.examprep.web;

import com.demo.examprep.model.view.OrderViewModel;
import com.demo.examprep.service.OrderService;
import com.demo.examprep.service.UserService;
import com.demo.examprep.util.CurrentUser;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@Controller
public class HomeController {
    private final CurrentUser currentUser;
    private final OrderService orderService;
    private final UserService userService;

    public HomeController(CurrentUser currentUser, OrderService orderService, UserService userService) {
        this.currentUser = currentUser;
        this.orderService = orderService;
        this.userService = userService;
    }

    @GetMapping("/")
    public String home(Model model){
        if (!currentUser.LoggedIn()) {
            return "index";
        }

        List<OrderViewModel> orders = orderService.getOrdersByPriceDesc();
        model.addAttribute("orders", orders);
        model.addAttribute("totalTime", orders
                .stream()
                .mapToInt(order -> order.getCategory().getNeeded_time())
                .sum());
        model.addAttribute("employees", userService.getUsersByOrdersCountDesc());

        return "home";
    }
}
