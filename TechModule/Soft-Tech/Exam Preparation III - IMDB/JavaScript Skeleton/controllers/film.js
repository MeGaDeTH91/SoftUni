const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        Film.find().then(films => {
            res.render('film/index', {'films': films});
        });
	},
	createGet: (req, res) => {
        res.render('film/create');
	},
	createPost: (req, res) => {
        let filmArgs = req.body;

        if(!filmArgs.name || !filmArgs.genre || !filmArgs.director || !filmArgs.year){
            res.redirect('/');
            return;
        }

        Film.create(filmArgs).then(film => {
            res.redirect('/');
        });
	},
	editGet: (req, res) => {
        let filmId = req.params.id;
        Film.findById(filmId).then(film => {
            if(!film) {
                res.redirect('/');
                return;
            }

            res.render('film/edit', film)
        });
	},
	editPost: (req, res) => {
        let filmId = req.params.id;  //дай ми Id-то на конкретния Task в променливата taskId
        let filmArgs = req.body;  //Дай ми новите данни, въведени във формата в taskArgs

        Film.findByIdAndUpdate(filmId, filmArgs, {runValidators : true}) // намери по Id и обнови конкретния Task
            .then(films => {  // Ако успееш - redirect-ни
                res.redirect("/");
            }).catch(err => {   // Ако не - дай грешка
            filmArgs.id = filmId;
            filmArgs.error = "Cannot edit Film.";
            return res.render('film/edit', filmArgs);
        });
	},
	deleteGet: (req, res) => {
        let id = req.params.id;
        Film.findById(id).then(film => {
            if(!film) {
                res.redirect('/');
                return;
            }

            res.render('film/delete', film)
        });
	},
	deletePost: (req, res) => {
        let id = req.params.id;

        Film.findByIdAndRemove(id).then(film => {
            res.redirect('/');
        });
    }
};