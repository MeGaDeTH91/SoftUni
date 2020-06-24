const mongoose = require('mongoose')
const { Schema, model: Model } = mongoose
const { String, ObjectId } = Schema.Types

const userSchema = new Schema({
    username: {
        type: String,
        required: true,
        unique: true
    },
    password: {
        type: String,
        require: true
    },
    someCollection: [ {
        type: ObjectId,
        ref: 'collectionType'
    }]
});

module.exports = new Model('User', userSchema);