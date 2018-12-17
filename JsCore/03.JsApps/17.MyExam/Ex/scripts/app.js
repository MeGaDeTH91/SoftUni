const app = Sammy('#site-content', function () {
    this.use('Handlebars', 'hbs');

    // GET REQUESTS
    this.get('#/', function () {
        auth.isAuthed() ? this.redirect('#/dashboard') : this.redirect('#/home');
    });
    this.get('#/home', function (ctx) {
        this.isAuthed = auth.isAuthed();

        if(auth.isAuthed()){
            this.redirect('#/dashboard');
        } else{
            this.loadPartials({
                navbar: 'templates/common/navbarAnon.hbs',
                footer : 'templates/common/footer.hbs'
            }).then(function () {
                this.partial('templates/home/welcome.hbs')
            });
        }
    });
    this.get('#/dashboard', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/my-pets', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.myPets = pets.filter(x => x.creator === context.username);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/pets/myPetsList.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/filter-cats', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username  && x.category === 'Cat').sort((a, b) => b.hearts - a.hearts);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/filter-dogs', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username  && x.category === 'Dog').sort((a, b) => b.hearts - a.hearts);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/filter-parrots', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username  && x.category === 'Parrot').sort((a, b) => b.hearts - a.hearts);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/filter-reptiles', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username  && x.category === 'Reptile').sort((a, b) => b.hearts - a.hearts);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/filter-other', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        petsService.loadPets()
            .then(function (pets) {
                context.pets = pets.filter(x => x.creator !== context.username  && x.category === 'Other').sort((a, b) => b.hearts - a.hearts);

                context.loadPartials({
                    navbar: 'templates/common/navbarAuth.hbs',
                    footer : 'templates/common/footer.hbs',
                }).then(function () {
                    context.partials = this.partials;
                    context.partial('templates/home/dashboard.hbs');
                });
            }).catch(notify.handleError);
    });
    this.get('#/register', function () {
        this.isAuthed = auth.isAuthed();
        this.loadPartials({
            navbar: 'templates/common/navbarAnon.hbs',
            footer : 'templates/common/footer.hbs'
        }).then(function () {
            this.partial('templates/register/register.hbs')
        });
    });
    this.get('#/logout', function (context) {
        if(auth.isAuthed()){
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    notify.showInfo('Logout successful.');
                    context.redirect('#/')
                }).catch(notify.handleError)
        }else{
            this.redirect('#/login');
        }

    });
    this.get('#/login', function () {
        if(!auth.isAuthed()){
            this.isAuthed = auth.isAuthed();
            this.loadPartials({
                navbar: 'templates/common/navbarAnon.hbs',
                footer : 'templates/common/footer.hbs'
            }).then(function () {
                this.partial('templates/login/login.hbs')
            });
        }else{
            this.redirect('#/');
        }
    });
    this.get('#/add-pet', function () {
        this.isAuthed = auth.isAuthed();
        if(auth.isAuthed()){
            this.username = sessionStorage.getItem('username');
            this.loadPartials({
                navbar: 'templates/common/navbarAuth.hbs',
                footer : 'templates/common/footer.hbs',
            }).then(function () {
                this.partial('templates/pets/addPet.hbs')
            });
        }else{
            this.redirect('#/login');
        }
    });
    this.get('#/delete-pet/:id', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        petsService.loadDetails(petId)
            .then(function (details) {
                debugger;
                if(details.creator === context.username){
                    context.name = details.name;
                    context.description = details.description;
                    context.hearts = details.hearts;
                    context.imageURL = details.imageURL;

                    context._id = details._id;
                    context.loadPartials({
                        navbar: 'templates/common/navbarAuth.hbs',
                        footer : 'templates/common/footer.hbs',
                    }).then(function () {
                        context.partials = this.partials;
                        context.partial('templates/pets/deletePet.hbs');
                    })
                }
            }).catch(notify.handleError)
    });
    this.get('#/edit-pet/:id', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        petsService.loadDetails(petId)
            .then(function (details) {
                debugger;
                if(details.creator === context.username){
                    context.name = details.name;
                    context.description = details.description;
                    context.hearts = details.hearts;
                    context.imageURL = details.imageURL;

                    context.category = details.category;

                    context._id = details._id;
                    context.loadPartials({
                        navbar: 'templates/common/navbarAuth.hbs',
                        footer : 'templates/common/footer.hbs',
                    }).then(function () {
                        context.partials = this.partials;
                        context.partial('templates/pets/detailsMyPet.hbs');
                    })
                }
            }).catch(notify.handleError)
    });
    this.get('#/details-pet/:id', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        petsService.loadDetails(petId)
            .then(function (details) {
                debugger;
                if(details.creator !== context.username){
                    context.name = details.name;
                    context.description = details.description;
                    context.hearts = details.hearts;
                    context.imageURL = details.imageURL;

                    context.category = details.category;

                    context._id = details._id;
                    context.loadPartials({
                        navbar: 'templates/common/navbarAuth.hbs',
                        footer : 'templates/common/footer.hbs',
                    }).then(function () {
                        context.partials = this.partials;
                        context.partial('templates/pets/detailsOtherPet.hbs');
                    })
                }
            }).catch(notify.handleError)
    });
    this.get('#/pet/:id', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        if(auth.isAuthed()){
            petsService.loadDetails(petId)
                .then(function (details) {
                    debugger;
                    if(details.creator !== context.username){
                        context.name = details.name;
                        context.description = details.description;
                        context.hearts = details.hearts;
                        context.imageURL = details.imageURL;
                        context.category = details.category;
                        context.hearts = +details.hearts + 1;
                        context._id = details._id;

                        petsService.editPet(petId, context.name, context.description, context.imageURL, context.category, context.hearts, details.creator)
                        context.loadPartials({
                            navbar: 'templates/common/navbarAuth.hbs',
                            footer : 'templates/common/footer.hbs',
                        }).then(function () {
                            context.partials = this.partials;
                            context.partial('templates/pets/detailsOtherPet.hbs');
                            context.redirect(`#/details-pet/${petId}`);
                        })
                    }
                }).catch(notify.handleError)
        }
    });
    this.get('#/pet-list/:id', function (context) {
        context.isAuthed = auth.isAuthed();
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        if(auth.isAuthed()){
            petsService.loadDetails(petId)
                .then(function (details) {
                    debugger;
                    if(details.creator !== context.username){
                        context.name = details.name;
                        context.description = details.description;
                        context.hearts = details.hearts;
                        context.imageURL = details.imageURL;
                        context.category = details.category;
                        context.hearts = +details.hearts + 1;
                        context._id = details._id;

                        petsService.editPet(petId, context.name, context.description, context.imageURL, context.category, context.hearts, details.creator)
                        context.loadPartials({
                            navbar: 'templates/common/navbarAuth.hbs',
                            footer : 'templates/common/footer.hbs',
                        }).then(function () {
                            context.partials = this.partials;
                            context.partial('templates/pets/detailsOtherPet.hbs');
                            context.redirect(`#/dashboard`);
                        })
                    }
                }).catch(notify.handleError)
        }
    });

    // POST REQUESTS
    this.post('#/register', function (context) {
        let username = context.params.username;
        let password = context.params.password;
        let validUser = /^[a-zA-Z0-9]{3,}$/.test(username);
        let validPass = /^[a-zA-Z0-9]{6,}$/.test(password);
        if (!username || !validUser){
            notify.showError('Username must be at least 3 symbols');
        } else if(!password || !validPass){
            notify.showError('Password must be at least 6 symbols');
        }
        else {
            auth.register(username, password)
                .then(function () {
                    notify.showInfo("User registration successful.");
                    auth.login(username, password)
                        .then(function (userInfo) {
                            auth.saveSession(userInfo);
                            notify.showInfo('Login successful.');
                            context.redirect('#/');
                        }).catch(notify.handleError);
                }).catch(notify.handleError);
        }
    });
    this.post('#/login', function (context) {
        let username = context.params.username;
        let password = context.params.password;
        let validUser = /^[a-zA-Z0-9]{3,}$/.test(username);
        let validPass = /^[a-zA-Z0-9]{6,}$/.test(password);
        if (!username || !validUser){
            notify.showError('Username must be at least 3 symbols');
        } else if(!password || !validPass){
            notify.showError('Password must be at least 6 symbols');
        }else {
            auth.login(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    notify.showInfo('Login successful.');
                    context.redirect('#/');
                }).catch(notify.handleError);
        }
    });

    this.post('#/add-pet', function (context) {
        let name = context.params.name;
        let description = context.params.description;
        let imageURL = context.params.imageURL;
        let category = context.params.category;
        let hearts = 0;
        let creator = sessionStorage.getItem('username');

        petsService.createNewPet(name, description, imageURL, category, hearts, creator)
            .then(function () {
                notify.showInfo('Pet created.');
                context.redirect('#/')
            }).catch(notify.handleError);
    });

    this.post('#/edit-pet/:id', function (context) {
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        petsService.loadDetails(petId)
            .then(function (details) {
                if(details.creator === context.username){
                    let name = details.name;
                    let description = context.params.description;
                    let category = details.category;
                    let hearts = details.hearts;
                    let imageURL = details.imageURL;
                    let creator = details.creator;
                    context._id = details._id;

                    debugger;
                    petsService.editPet(petId, name, description, imageURL, category, hearts, creator)
                        .then(function () {

                            debugger;
                            notify.showInfo('Updated successfully!');
                            context.redirect('#/my-pets')
                        }).catch(notify.handleError);
                }
            }).catch(notify.handleError)
    });

    this.post('#/delete-pet/:id', function (context) {
        context.username = sessionStorage.getItem('username');

        let petId = context.params.id;

        requester.get('appdata', 'pets/' + petId, 'kinvey')
            .then(function (response) {
                if(response.creator === context.username){
                    petsService.deletePet(petId)
                        .then(function () {
                            notify.showInfo('Pet removed successfully!');
                            context.redirect('#/');
                        }).catch(notify.handleError);
                }
            });
    });
});

$(function(){
    app.run('#/');
});