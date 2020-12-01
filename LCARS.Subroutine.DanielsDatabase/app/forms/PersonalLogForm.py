from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField

class PersonalLogForm(FlaskForm):
    """description of class"""
    add_input = StringField('Entry')
