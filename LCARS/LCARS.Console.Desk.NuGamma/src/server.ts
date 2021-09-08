import App from './app'

import * as bodyParser from 'body-parser'
import HomeController from './controllers/home';
import loggerMiddleware from './middleware/logger';

const port = normalizePort(process.env.PORT || 1337);

function normalizePort(value: string | number): number | string | boolean {
    let port: number = (typeof value === 'string') ? parseInt(value, 10) : value;
    if (isNaN(port)) return value;
    else if (port >= 0) return port;
    else return false;
}

const app = new App({
    port: port,
    controllers: [
        new HomeController()
    ],
    middlewares: [
        bodyParser.json(),
        bodyParser.urlencoded({ extended: true }),
        loggerMiddleware
    ]
})

app.listen();
