const mongoose = require('mongoose');
const config = require('../config/config');

mongoose.connect(config.dbURL, { 
  useNewUrlParser: true,
  useUnifiedTopology: true,
  useCreateIndex: true
}, (err) => {  
  if (err) {
    console.log(err);
    throw err;
  }

  console.log("Database up and running!");
});
