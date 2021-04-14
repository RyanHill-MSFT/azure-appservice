import json
import logging

import azure.functions as func
from azure.storage.filedatalake import DataLakeServiceClient

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

def initialize_storage_account(storage_account_name, storage_account_key):
    try:
        global service_client

        service_client = DataLakeServiceClient(
            account_url="{}://{}.dfs.core.windows.net".format("https",storage_account_name),
            credential=storage_account_key)
    except Exception as e:
        print(e)