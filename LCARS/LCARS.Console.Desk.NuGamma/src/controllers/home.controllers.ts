import * as express from 'express'
import { Request, Response } from 'express'
import IControllerBase from '../interfaces/IControllerBase.interface'

class HomeController implements IControllerBase {
    public path = '/'
    public router = express.Router()

    constructor() {
        this.initRoutes()
    }

    public initRoutes() {
        this.router.get('/', (req: Request, res: Response, next) => {
            res.json({
                message: "Hello World!"
            });
        });
    }
}

export default HomeController