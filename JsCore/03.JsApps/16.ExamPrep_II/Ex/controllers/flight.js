const flight = function () {
    const addGet = function (ctx) {
        if(userModel.isAuthorized()){
            ctx.partial('views/flight/add.hbs');
        }else{
            ctx.redirect('#/login');
        }
    };

    const addPost = function (ctx) {
        flightModel.add(ctx.params).done(function () {
            notify.showInfo('Created flight.');
            ctx.redirect('#/');
        });
    };
    return {
        addGet,
        addPost
    }
}();