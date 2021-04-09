import json
import logging

import azure.functions as func


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Transporter received target coordinate request')

    site = req.params.get('site')
    if not site:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            site = req_body.get('site')

    if site:
        return func.HttpResponse(f"Coordinates, {site} successfully received")
    else:
        return func.HttpResponse(
             "TransporterTargetCoordinates function executed successfully. Pass a transport site in the query string or in the request body for a personalized response.",
             status_code=200
        )
