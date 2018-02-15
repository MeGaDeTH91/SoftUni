package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

import java.util.List;

@Controller
public class TaskController {
	private final TaskRepository taskRepository;

	@Autowired
	public TaskController(TaskRepository taskRepository) {
		this.taskRepository = taskRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Task> tasksOpen = taskRepository.findAllByStatus("Open");
		//List<Task> tasks = taskRepository.findAll();  -->> Втори вариант, със stream
		// List<Task> openTasks = tasks.stream()
		// .filter(t -> t.getStatus().equals("Open"))
		// .collect(Collectors.toList());
		List<Task> tasksInProgress = taskRepository.findAllByStatus("In Progress");
		List<Task> tasksFinished = taskRepository.findAllByStatus("Finished");

		model.addAttribute("openTasks", tasksOpen);
		model.addAttribute("inProgressTasks", tasksInProgress);
		model.addAttribute("finishedTasks", tasksFinished);

		model.addAttribute("view", "task/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "task/create");
		return "base-layout";
	}

	@PostMapping("/create")
	public String createPost(Model model, Task taskModel) {
		if(taskModel == null){
			model.addAttribute("view", "task/create");
			return "base-layout";
		}

		if(taskModel.getTitle().equals("") || taskModel.getStatus().equals("")){
			model.addAttribute("task", taskModel);
			model.addAttribute("view", "task/create"); // Redirect-ваме към task/create
			return "base-layout";
		}

		taskRepository.saveAndFlush(taskModel); // Запазваме в Базата
		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {

	Task task = taskRepository.findOne(id); // Намираме конкретния Task по ID

        if(task == null){
		return "redirect:/";
	}
		model.addAttribute("task", task);
        model.addAttribute("view", "task/edit");
        return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editPost(Model model, @PathVariable int id,
						   Task taskModel) {

		if(taskModel.getTitle().equals("") ||
				taskModel.getStatus().equals("")){
			taskModel.setId(id);
			model.addAttribute("task", taskModel);
			model.addAttribute("view", "task/edit"); // Redirect-ваме към task/edit
			return "base-layout";
		}

		Task task = taskRepository.findOne(id); // Намираме конкретния Task по ID

		if(task == null){
			return "redirect:/";
		}

		task.setTitle(taskModel.getTitle());
		task.setStatus(taskModel.getStatus());
		taskRepository.saveAndFlush(task);

		return "redirect:/";
	}
}
