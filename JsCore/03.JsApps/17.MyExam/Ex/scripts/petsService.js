let petsService = (() => {
    function loadPets() {
        return requester.get('appdata', `pets?query={}&sort={"_kmd.ect": -1}`, 'kinvey');
    }
    function loadDetails(petId) {
        return requester.get('appdata', `pets/${petId}`, 'kinvey');
    }
    function createNewPet(name, description, imageURL, category, hearts, creator) {
        let data = {
            name, description, imageURL, category, hearts, creator
        };
        return requester.post('appdata', 'pets', 'kinvey', data)
    }

    function editPet(petId, name, description, imageURL, category, hearts, creator) {
        let data = {
            name,
            description,
            imageURL,
            category,
            hearts,
            creator
        };

        return requester.update('appdata', 'pets/' + petId, 'kinvey', data)
    }
    function deletePet(petId) {
        return requester.remove('appdata', 'pets/' + petId, 'kinvey');
    }
    function loadMyPets(username) {
        return requester.get('appdata', `pets?query={"creator":"${username}"}&sort={"_kmd.ect": -1}`, 'kinvey');

    }

    return {
        loadPets,
        createNewPet,
        loadDetails,
        editPet,
        deletePet,
        loadMyPets
    }
})();