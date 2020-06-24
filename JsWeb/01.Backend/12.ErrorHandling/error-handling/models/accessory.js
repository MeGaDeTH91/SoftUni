const mongoose = require('mongoose')

const AccessorySchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        match: [/[A-Za-z0-9 _]/, 'Accessory name is not valid.'],
        minlength: 5
    },
    description: {
        type: String,
        required: true,
        match: [/[A-Za-z0-9 _]/, 'Accessory description is not valid.'],
        minlength: 20,
        maxlength: 200
    },
    imageUrl: {
        type: String,
        required: true
    },
    cubes: [{
        type: 'ObjectId',
        ref: 'Cube'
    }]
})

AccessorySchema.path('imageUrl').validate(function(url) {
    return url.startsWith('http://') || url.startsWith('https://')
}, 'Image url is not valid!')

module.exports = mongoose.model('Accessory', AccessorySchema)