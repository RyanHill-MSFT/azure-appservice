from flask import current_app
from . import api_bp

@api_bp.route("/api/data")
def getDataJson():
    return current_app.send_static_file("data.json")
