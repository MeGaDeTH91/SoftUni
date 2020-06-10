const { getCubes, getSpecificCube, saveCube, searchCubes } = require('./database-controller')

const getAllCubes = (callback) => {
    getCubes((cubes) => {
        callback(cubes)
    })
}

const getCube = (id, callback) => {
    getSpecificCube(id, (cube) => {
        callback(cube)
    })
}

const getSearchedCubes = (paramsObj, callback) => {
    searchCubes(paramsObj, (cubes) => {
        callback(cubes)
    })
}

const createCube = (cube) => {
    saveCube(cube)
}

module.exports = {
    getAllCubes,
    getCube,
    createCube,
    getSearchedCubes
}