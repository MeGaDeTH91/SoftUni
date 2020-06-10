const { v4 : generateUid } = require('uuid')
const { saveCube } = require('../controllers/database-controller')

class Cube{
    constructor(name, description, imageURL, difficulty) {
        this.id = generateUid()
        this.name = name
        this.description = description,
        this.imageURL = imageURL,
        this.difficulty = difficulty
    }

    save(callback) {
        const cubeToStore = {
            id : this.id,
            name : this.name,
            description : this.description,
            imageURL : this.imageURL,
            difficulty : this.difficulty
        }
        
        saveCube(cubeToStore, callback)
    }
}

module.exports = Cube