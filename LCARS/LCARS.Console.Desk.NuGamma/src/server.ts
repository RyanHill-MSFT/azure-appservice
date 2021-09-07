import { debug } from "console";
import * as http from "http";
import { normalize } from "path";
import app from "./app";

const port = normalizePort(process.env.PORT || 1337);
app.set("port", port);

const server = http.createServer(app);
server.listen(port);
server.on("listening", onListening);
server.on("error", onError);

function normalizePort(value: string | number): number | string | boolean {
    let port: number = (typeof value === 'string') ? parseInt(value, 10) : value;
    if (isNaN(port)) return value;
    else if (port >= 0) return port;
    else return false;
}

function onError(error: NodeJS.ErrnoException): void {
    if (error.syscall !== 'listen') throw error;
    let bind = (typeof port === 'string') ? 'Pipe ' + port : 'Port ' + port;
    switch (error.code) {
        case 'EACCES':
            console.error(`${bind} requires elevated privileges`);
            process.exit(1);
            break;
        case 'EADDRINUSE':
            console.error(`${bind} is already in use`);
            process.exit(1);
            break;
        default:
            throw error;
    }
}

function onListening(): void {
    let addr = server.address();
    let bind = (typeof addr === "string") ? `pipe ${addr}` : `port ${addr.port}`;
    debug(`Listening on ${bind}`);
}
