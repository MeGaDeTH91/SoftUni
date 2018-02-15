const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
		//let tasksAll = Task.find(); // Това връща Promise - Асинхронна задача
        //Втори начин ->
        //let tasksPromises = [        // Това е масив от 3-та типа задачи едновременно
             //Task.find({status: "Open"}),
            //Task.find({status: "In Progress"}),
            //Task.find({status: "Finished"})];

        //Promise.all(tasksPromises).then(taskResults => {   // Като се изпълнят и трите горни Task.find тогава продължаваме
            //res.render('task/index',
                //{
                    //'openTasks': taskResults[0],
                    //'inProgressTasks': taskResults[1],
                    //'finishedTasks': taskResults[2],
                //});
        //});

        Task.find().then(tasks => {   // Намери ми всички Tasks и после ми ги рендирай филтрирани според status
            res.render('task/index', {
                'openTasks' : tasks.filter(t => t.status === "Open"),
                'inProgressTasks' : tasks.filter(t => t.status === "In Progress"),
                'finishedTasks' : tasks.filter(t => t.status === "Finished")
            })
        });

	},
	createGet: (req, res) => {
		res.render('task/create');
	},
	createPost: (req, res) => {
        let taskArgs = req.body;

        if(!taskArgs.title || !taskArgs.status){
            res.redirect('/');
            return;
        }

        Task.create(taskArgs).then(task => {
            res.redirect('/');
        });
	},
	editGet: (req, res) => {
        let taskId = req.params.id;
        Task.findById(taskId).then(task => {
            if(!task) {
                res.redirect('/');
                return;
            }

            res.render('task/edit', task)
        });
	},
	editPost: (req, res) => {
        let taskId = req.params.id;  //дай ми Id-то на конкретния Task в променливата taskId
        let taskArgs = req.body;  //Дай ми новите данни, въведени във формата в taskArgs

        Task.findByIdAndUpdate(taskId, taskArgs, {runValidators : true}) // намери по Id и обнови конкретния Task
            .then(tasks => {  // Ако успееш - redirect-ни
                res.redirect("/");
            }).catch(err => {   // Ако не - дай грешка
                taskArgs.id = taskId;
                taskArgs.error = "Cannot edit task.";
                return res.render('task/edit', taskArgs);
        });
    }
};