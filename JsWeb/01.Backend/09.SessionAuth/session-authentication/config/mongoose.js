const env = process.env.NODE_ENV || 'development';
const mongoose = require('mongoose')
mongoose.set('useCreateIndex', true)
const config = require('../config/config')[env]

mongoose.connect(config.dbURL, { 
  useNewUrlParser: true,
  useUnifiedTopology: true
}, (err) => {  
  if (err) {
    console.log(err)
    throw err
  }

  console.log("Database up and running!")
});
