import os

from app import app

basedir = os.path.abspath(os.path.dirname(__file__))

class Config(object):
    """description of class"""
    FLASK_ENV = os.getenv('FLASK_ENV', 'production')

app.config.from_object('app.config.Config')