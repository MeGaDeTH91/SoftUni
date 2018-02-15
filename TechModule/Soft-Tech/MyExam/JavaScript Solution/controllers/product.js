const Product = require('../models/Product');

module.exports = {
	index: (req, res) => {
        Product.find().then(products => {
            res.render('product/index', {'entries': products});
        });
    	},
	createGet: (req, res) => {
        res.render('product/create');
	},
	createPost: (req, res) => {
        let productArgs = req.body;

        if(!productArgs.name || !productArgs.quantity || !productArgs.priority){
            res.redirect('/');
            return;
        }

        Product.create(productArgs).then(product => {
            res.redirect('/');
        });
	},
	editGet: (req, res) => {
        let productId = req.params.id;
        Product.findById(productId).then(product => {
            if(!product) {
                res.redirect('/');
                return;
            }

            res.render('product/edit', product)
        });
	},
	editPost: (req, res) => {
        let productId = req.params.id;  //дай ми Id-то на конкретния Task в променливата taskId
        let productArgs = req.body;  //Дай ми новите данни, въведени във формата в taskArgs

        Product.findByIdAndUpdate(productId, productArgs, {runValidators : true}) // намери по Id и обнови конкретния Task
            .then(products => {  // Ако успееш - redirect-ни
                res.redirect("/");
            }).catch(err => {   // Ако не - дай грешка
            productArgs.id = productId;
            productArgs.error = "Cannot edit Product.";
            return res.render('product/edit', productArgs);
        });
	}
};