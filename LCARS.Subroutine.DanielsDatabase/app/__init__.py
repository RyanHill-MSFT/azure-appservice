import os
import sys
import logging
import pyodbc

from flask import Flask

sys.path.append(os.path.dirname(os.path.dirname(os.path.realpath(__file__))))
from config import Config
from flask_sqlalchemy import SQLAlchemy

handler = logging.StreamHandler(stream=sys.stdout)
logger = logging.getLogger('azure')
logger.setLevel(logging.DEBUG)
logger.addHandler(handler)

app = Flask(__name__)
app.config.from_object(Config)

db = SQLAlchemy(app)
logger.debug(pyodbc.version)
# Import here to avoid circular imports
from app import routes
