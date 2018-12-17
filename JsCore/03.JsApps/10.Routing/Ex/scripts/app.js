$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');

        this.get('/index.html', displayHomeRoute);

        this.get('#/home', displayHomeRoute);
        
        this.get('#/about', aboutGetRoute);

        this.get('#/catalog', catalogGetRoute);
        this.get('#/catalog/:id', catalogRouteById);
        this.get('#/create', createTeamGetRoute);
        this.post('#/create', createTeamPostRoute);

        this.get('#/login', loginGetRoute);
        this.post('#/login', loginPostRoute);

        this.get('#/register', registerGetRoute);
        this.post('#/register', registerPostRoute);

        this.get('#/logout', logoutGetRoute);

        function ctxHandler(ctx) {
            ctx.loggedIn = sessionStorage.getItem('userId') !== null;
            ctx.username = sessionStorage.getItem('username');
            ctx.teamId = sessionStorage.getItem('teamId');
        }

        function displayHomeRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');
            context.teamId = sessionStorage.getItem('teamId') !== 'undefined' ||
                             sessionStorage.getItem('teamId') !== null;

            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            }).then(function () {
                this.partial('./templates/home/home.hbs')
            }).catch(auth.handleError)
        }

        function aboutGetRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            this.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            }).then(function () {
                this.partial('./templates/about/about.hbs')
            }).catch(auth.handleError)
        }

        function catalogGetRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');
            context.teamId = sessionStorage.getItem('teamId') !== 'undefined' ||
                sessionStorage.getItem('teamId') !== null;
            context.hasNoTeam = context.teamId === 'undefined';

            if(context.loggedIn){
                context.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    team: './templates/catalog/team.hbs'
                }).then(function () {
                    teamsService.loadTeams()
                        .then((response) => {
                            context.teams = response;
                            this.partial('./templates/catalog/teamCatalog.hbs')
                        }).catch(auth.handleError);
                });
            } else{
                auth.showError('You must log in first!')
                this.redirect('#/login');
            }
        }

        function createTeamGetRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            if(context.loggedIn){
                context.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    createForm: './templates/create/createForm.hbs'
                }).then(function () {
                    this.partial('./templates/create/createPage.hbs')
                }).catch(auth.handleError);
            } else{
                auth.showError('You must log in first!')
                this.redirect('#/login');
            }
        }
        function createTeamPostRoute(context){
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');
            let isOnTeam = context.teamId == "undefined";

            debugger;
            if(context.loggedIn){
                let teamName = this.params.name;
                let teamDescription = this.params.comment;

                if (isOnTeam) {
                    auth.showError('You are not allow to create until leave the current team!');
                    this.redirect(`#/catalog`);
                    return;
                }

                teamsService.createTeam(teamName, teamDescription);
            } else{
                auth.showError('You must log in first!');
                this.redirect('#/login');
            }
        }

        function loginGetRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            this.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs'
            }).then(function () {
                this.partial('./templates/login/loginPage.hbs')
            }).catch(auth.handleError)
        }
        function loginPostRoute(context) {
            let username = this.params.username;
            let password = this.params.password;

            auth.login(username, password)
                .then(function (response) {
                    auth.saveSession(response);
                    auth.showInfo('You were logged in successfully!');
                    displayHomeRoute(context);
                }).catch(auth.handleError);
        }

        function registerGetRoute(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            this.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: './templates/register/registerForm.hbs'
            }).then(function () {
                this.partial('./templates/register/registerPage.hbs')
            }).catch(auth.handleError)
        }
        function registerPostRoute(context) {
            let username = this.params.username;
            let password = this.params.password;
            let repeatPass = this.params.repeatPassword;

            if(password !== repeatPass){
                auth.showError('Given passwords do not match!')
            } else{
                auth.register(username, password, repeatPass)
                    .then(function (response) {
                        auth.saveSession(response);
                        auth.showInfo('You were registered successfully!');
                        displayHomeRoute(context);
                    }).catch(auth.handleError);
            }
        }

        function logoutGetRoute(context) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('You were logger out successfully!');
                    displayHomeRoute(context);
                }).catch(auth.handleError);

        }

        function catalogRouteById(ctx) {
            let teamId = ctx.params.id.substring(1);
            teamsService.loadTeamDetails(teamId)
                .then(function (teamData) {

                    debugger;
                    ctx.loggedIn = sessionStorage.getItem('username') !== null;
                    ctx.username = sessionStorage.getItem('username');

                    ctx.teamId = teamData._id;
                    ctx.name = teamData.name;
                    ctx.comment = teamData.comment;
                    ctx.isOnTeam = sessionStorage.getItem('teamId') === teamData._id;
                    ctx.isAuthor = sessionStorage.getItem('userId') === teamData._acl.creator;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        teamControls: './templates/catalog/teamControls.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/details.hbs');
                    });
                });
        }
    });

    app.run();
});