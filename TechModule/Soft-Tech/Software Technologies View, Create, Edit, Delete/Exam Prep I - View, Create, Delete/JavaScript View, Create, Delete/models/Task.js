const mongoose = require('mongoose');

let taskSchema = mongoose.Schema({
    title: {type:'string', required: 'true'},
    comments: {type:'string', required: 'true'}
});

let Task = mongoose.model('task', taskSchema);

module.exports = Task;