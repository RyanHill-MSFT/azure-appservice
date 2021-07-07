from datetime import date, datetime

from flask import Blueprint, render_template

general_bp = Blueprint("general", __name__)

@general_bp.route("/")
def home():
    return render_template("home.html")

@general_bp.route("/about/")
def about():
    return render_template("about.html")

@general_bp.route("/contact/")
def contact():
    return render_template("contact.html")

@general_bp.route("/hello/")
@general_bp.route("/hello/<name>")
def indexName(name = None):
    return render_template(
        "hello_there.html",
        name=name,
        date=datetime.now()
    )

