import * as express from 'express'
import { Application } from 'express'

class App {
    public app: Application;
    public port: number | string | boolean;

    constructor(appInit: { port: number | string | boolean; middlewares: any; controllers: any; }) {
        this.app = express();
        this.port = appInit.port;

        this.middleware(appInit.middlewares);
        this.routes(appInit.controllers);
    }

    private middleware(middleWares: { forEach: (arg0: (middleWare: any) => void) => void; }): void {
        middleWares.forEach(middleWare => {
            this.app.use(middleWare);
        })
    }

    private routes(controllers: { forEach: (arg0: (controller: any) => void) => void; }): void {
        controllers.forEach(controller => {
            this.app.use("/", controller.router);
        })
    }

    public listen(): void {
        this.app.listen(this.port, () => {
            console.log(`App listening on http://localhost:${this.port}`);
            console.log(`App environment: ${process.env.NODE_ENV}`);
        })
    }
}

export default App;