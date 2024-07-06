import dotenvFlow from "dotenv-flow";
dotenvFlow.config();

const axios = require('axios').default
axios.defaults.validateStatus = () => true;