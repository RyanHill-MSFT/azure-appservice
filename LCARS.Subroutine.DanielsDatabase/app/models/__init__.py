from app import db

class LogEntry(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    text = db.Column(db.String(200))
