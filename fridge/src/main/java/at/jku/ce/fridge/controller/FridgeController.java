package at.jku.ce.fridge.controller;

import at.jku.ce.fridge.model.Fridge;
import at.jku.ce.fridge.model.ShoppingList;
import at.jku.ce.fridge.service.IFridgeService;
import at.jku.ce.fridge.service.IShoppingListService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
public class FridgeController {

    @Autowired
    private final IFridgeService fridgeService;

    FridgeController (IFridgeService fridgeService) {
        this.fridgeService = fridgeService;
    }

    @GetMapping("/fridge")
    public List<Fridge> getAllFridges() {
        return fridgeService.findAll();
    }

    @GetMapping("/fridge/{id}")
    public Optional<Fridge> getFridge(@PathVariable Long id) {
        return fridgeService.findById(id);
    }

    @DeleteMapping("/fridge/{id}")
    void deleteFridge(@PathVariable Long id) {
        if(fridgeService.findById(id).isPresent()) {
            fridgeService.deleteById(id);
        }
    }

    @PostMapping(value = "/fridge", consumes = {"application/json"})
    Fridge newFridge(@RequestBody Fridge fridge) {
        return fridgeService.save(fridge);
    }



}
