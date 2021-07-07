import os

from flask import Flask


def create_app(config_filename=None):
    app = Flask(__name__, instance_relative_config=True)
    app.config.from_mapping(
        SECRET_KEY='dev',
        DATABASE=os.path.join(app.instance_path, "local.sqlite")
    )

    if config_filename is None:
        app.config.from_pyfile("config.py", silent=True)
    else:
        app.config.from_mapping(config_filename)

    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    from padd.general.general import general_bp
    from padd.api import api_bp
    
    app.register_blueprint(general_bp)
    app.register_blueprint(api_bp)

    return app
