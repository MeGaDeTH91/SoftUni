const Cube = require('../models/cube')
const Accessory = require('../models/accessory')

const getCubes = async () => {
    const cubes = await Cube.find().lean()

    return cubes
}

const getCube = async (id) => {
    const cube = await Cube.findById(id).lean()

    return cube
}

const getCubeWithAccessories = async (id) => {
    const cube = await Cube.findById(id).populate('accessories').lean()

    return cube
}

const searchCubes = async (paramsObj) => {
    const searchName = paramsObj.search

    let searchedCubes = await getCubes()

    if (searchName) {
        searchedCubes = searchedCubes.filter(x => x.name.toLowerCase().includes(searchName.toLowerCase()))
    }

    if (paramsObj.from) {
        const searchFrom = parseInt(paramsObj.from)
        searchedCubes = searchedCubes.filter(x => x.difficulty >= searchFrom)
    }

    if (paramsObj.to) {
        const searchTo = parseInt(paramsObj.to)
        searchedCubes = searchedCubes.filter(x => x.difficulty <= searchTo)
    }

    return searchedCubes
}

const updateCube = async (cubeId, accessoryId) => {
    await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            accessories: [accessoryId]
        }
    })

    await Accessory.findByIdAndUpdate(accessoryId, {
        $addToSet: {
          cubes: [cubeId],
        },
      })
}

module.exports = {
    getCubes,
    getCube,
    searchCubes,
    updateCube,
    getCubeWithAccessories
}