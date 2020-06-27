# Project Topic

Project description

## Installation

Run npm/yarn install in the project root folder so all list dependencies in package.json are installed

## Usage
You can start the project by running npm start from terminal
Main entry point is the index.js file, located in the root directory.
The home Url is localhost:${theSpecifiedPort}/home

The project uses dotenv dependency and the database is from cloud provider - MongoDb Atlas.
If for some reason .env file is missing in the root folder, please create one with the following keys:
PORT=4000
DB_URL=mongodb+srv://examUser:examPass@aws-8thve.mongodb.net/js-exam?retryWrites=true&w=majority
COOKIE_KEY=some-cool-token
PRIVATE_KEY=the_most_secret_key_like_ever