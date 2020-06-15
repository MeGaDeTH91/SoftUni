const dotenv = require('dotenv')
const mongoose = require('mongoose')
dotenv.config()

const user = process.env.DB_USER || ""
const password = process.env.DB_PASSWORD || ""
const uri = `mongodb+srv://${user}:${password}@aws-8thve.mongodb.net/js-backend?retryWrites=true&w=majority`;

mongoose.connect(uri, { 
  useNewUrlParser: true,
  useUnifiedTopology: true
}, (err) => {  
  if (err) {
    console.log(err)
    throw err
  }

  console.log("Database up and running!")
});
