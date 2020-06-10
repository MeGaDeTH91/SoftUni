const fs = require('fs')
const path = require('path')
const Cube = require('../models/cube')
const DatabaseFile = path.join(__dirname, '..', 'config/database.json')

const saveCube = (cube, callback) => {
    getCubes((cubes) => {
        cubes.push(cube)

        fs.writeFile(DatabaseFile, JSON.stringify(cubes), error => {
            if (error) {
                throw error
            }

            console.log("Cube stored successfully!")
            callback()
        })
    })
}

const getCubes = (callback) => {
    fs.readFile(DatabaseFile, (err, data) => {
        if (err) {
            throw err
        }

        const cubes = JSON.parse(data)
        callback(cubes)
    })
}

const getSpecificCube = (id, callback) => {
    getCubes((cubes) => {
        const cube = cubes.find(x => x.id === id)
        callback(cube)
    })
}

const searchCubes = (paramsObj, callback) => {
    getCubes((cubes) => {
        const searchName = paramsObj.search
        const searchFrom = paramsObj.from
        const searchTo = paramsObj.to

        console.log(searchName, "NAMEE")
        console.log(searchFrom, "FROMM")
        console.log(searchTo, "TOO")

        let searchedCubes = Array.from(cubes)

        if (searchName) {
            searchedCubes = searchedCubes.filter(x => x.name.toLowerCase().includes(searchName.toLowerCase()))
        }

        if (searchFrom) {
            searchedCubes = searchedCubes.filter(x => x.difficulty >= searchFrom) 
        }
        
        if (searchTo) {
            searchedCubes = searchedCubes.filter(x => x.difficulty <= searchTo) 
        }
        
        callback(searchedCubes)
    })
}

module.exports = {
    getCubes,
    getSpecificCube,
    saveCube,
    searchCubes
}