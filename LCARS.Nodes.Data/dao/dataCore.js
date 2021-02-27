const { MongoClient } = require('mongodb');
const ObjectId = require('mongodb').ObjectID;
// read .env file
require('dotenv').config();

const DATABASE_URL = process.env.DATABASE_URL
    ? process.env.DATABASE_URL
    : 'mongodb://localhost:27017';
const DATABASE_NAME = process.env.DATABASE_NAME;
const DATABASE_COLLECTION_NAME = process.env.DATABASE_COLLECTION_NAME;

let mongoConnection = null;
let db = null;

console.log(`DB:${DATABASE_URL}`);

const connect = async (url) => {
    if (!url) throw Error('connect::missing required params');
    return MongoClient.connect(url, { useUnifiedTopology: true });
};

const connectToDatabase = async () => {
    try {
        if (!DATABASE_URL || !DATABASE_NAME) {
            console.log('DB required params are missing');
            console.log(`DB required params DATABASE_URL = ${DATABASE_URL}`);
            console.log(`DB required params DATABASE_NAME = ${DATABASE_NAME}`);
        }

        mongoConnection = await connect(DATABASE_URL);
        db = mongoConnection.db(DATABASE_NAME);

        return !!db;
    } catch (err) {
        console.log('DB not connected - err::');
        console.log(err);
    }
};