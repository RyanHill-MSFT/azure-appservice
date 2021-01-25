import os

basedir = os.path.abspath(os.path.dirname(__file__))

class Config(object):
    """description of class"""
    FLASK_ENV = os.environ.get('FLASK_ENV') or 'production'
    SECRET_KEY = os.environ.get('SECRET_KEY') or 'secret-key'
    SQLALCHEMY_DATABASE_URI = os.environ.get('DATABASE_URL') or \
        'sqlite:///' + os.path.join(basedir, 'app.db')
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    INSTRUMENTATION_KEY = os.environ.get('APPINSIGHTS_INSTRUMENTATIONKEY') or \
        '<your-ikey-here>'
    CONNECTION_STRING = 'InstrumentationKey=' + INSTRUMENTATION_KEY
