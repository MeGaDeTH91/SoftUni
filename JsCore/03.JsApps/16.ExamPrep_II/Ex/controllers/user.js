const user = (function(){
    const getLogin = function(ctx){
        ctx.partial('views/user/login.hbs');
    };

    const postLogin = function(ctx){
        var username = ctx.params.username;
        var password = ctx.params.pass;
        
        userModel.login(username, password).done(function(data){
            storage.saveUser(data);

            notify.showInfo('Login successful!');
            ctx.redirect('#/');
        }).fail(function () {
            notify.showError('Invalid credentials!');
        });
    };

    const logout = function(ctx){
        userModel.logout().done(function(){
            storage.deleteUser();

            notify.showInfo('Logged out successfully!');
            ctx.redirect('#/');
        });
    }

    const getRegister = function(ctx) {
        ctx.partial('views/user/register.hbs');
    };

    const postRegister = function(ctx) {
        userModel.register(ctx.params).done(function(data){
            storage.saveUser(data);

            notify.showInfo('User registration successful.');
            ctx.redirect('#/');
        });
    }

    const initializeLogin = function(){
        let userInfo = storage.getData('userInfo');

        if(userModel.isAuthorized()){
            $('#userViewName').text(userInfo.username);
            $('#logoutContainer').removeClass('d-none');
            $('.hide-when-logged-in').addClass('d-none');
            $('.show-when-logged-in').removeClass('d-none');
        } else{
            $('#logoutContainer').addClass('d-none');
            $('.hide-when-logged-in').removeClass('d-none');
            $('.show-when-logged-in').addClass('d-none');
        }
    };

    return {
        getLogin,
        postLogin,
        logout,
        getRegister,
        postRegister,
        initializeLogin
    };
}());