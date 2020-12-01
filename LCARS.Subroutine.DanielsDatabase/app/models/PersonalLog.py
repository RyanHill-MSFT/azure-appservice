import datetime

from datetime import date
from app import db

class PersonalLog(db.Model):
    """description of class"""
    __tablename__ = 'personallog'
    Stardate = db.Column(db.Date)
    Entry = db.Column(db.String)

    def __init__(self, entry):
        self.Entry = entry
        self.Stardate = date.today
