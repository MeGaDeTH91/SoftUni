package com.java.exam.web;

import com.java.exam.model.binding.FireBindingModel;
import com.java.exam.model.view.ShipViewModel;
import com.java.exam.model.view.UserViewModel;
import com.java.exam.service.ShipService;
import com.java.exam.service.UserService;
import com.java.exam.util.CurrentUser;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.validation.Valid;
import java.util.List;
import java.util.stream.Collectors;

@Controller
public class HomeController {
    private final CurrentUser currentUser;
    private final ShipService shipService;
    private final UserService userService;

    @ModelAttribute
    public FireBindingModel fireBindingModel() {
        return new FireBindingModel();
    }

    public HomeController(CurrentUser currentUser, ShipService shipService, UserService userService) {
        this.currentUser = currentUser;
        this.shipService = shipService;
        this.userService = userService;
    }

    @GetMapping("/")
    public String home(Model model){
        if (!currentUser.LoggedIn()) {
            return "index";
        }
        UserViewModel loggedUser = userService.getUserViewModelById(currentUser.getId());
        if (loggedUser == null) {
            return "index";
        }

        List<ShipViewModel> allShips = shipService.getShipsOrderedByPowerThenHealth();
        List<ShipViewModel> defendingShips = allShips
                .stream()
                .filter(ship -> loggedUser.getShips().stream().noneMatch(userShip -> ship.getId().equals(userShip.getId())))
                .collect(Collectors.toList());
        model.addAttribute("attackingShips", loggedUser.getShips());
        model.addAttribute("defendingShips", defendingShips);
        model.addAttribute("ships", allShips);

        return "home";
    }

    @PostMapping("/")
    public String homeFire(@Valid FireBindingModel fireBindingModel,
                           BindingResult bindingResult, RedirectAttributes redirectAttributes){

        if (bindingResult.hasErrors()) {
            redirectAttributes
                    .addFlashAttribute("fireBindingModel", fireBindingModel)
                    .addFlashAttribute("org.springframework.validation.BindingResult.fireBindingModel", bindingResult);
            return "redirect:/";
        }

        ShipViewModel attackingShip = shipService.getShipViewModelById(fireBindingModel.getAttacker());
        ShipViewModel defendingShip = shipService.getShipViewModelById(fireBindingModel.getDefender());

        defendingShip.setHealth(defendingShip.getHealth() - attackingShip.getPower());
        if (defendingShip.getHealth() <= 0) {
            shipService.removeShipById(defendingShip.getId());
        } else {
            shipService.setNewShipHealth(defendingShip.getId(), defendingShip.getHealth());
        }

        return "redirect:/";
    }
}
