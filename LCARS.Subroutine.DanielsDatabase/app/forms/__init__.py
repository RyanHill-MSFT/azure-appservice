from flask_wtf import FlaskForm
from wtforms import fields

class LogEntryForm(FlaskForm):
    """description of class"""
    add_input = fields.StringField('Entry')
    valid_submit = fields.SubmitField('Save')
