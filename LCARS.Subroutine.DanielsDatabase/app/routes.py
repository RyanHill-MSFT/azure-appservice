import json

from flask import render_template, redirect, request, url_for

from app import app, db
from app.forms import LogEntryForm
from app.models import LogEntry

@app.route('/')
def index():
    return "Hello World"

@app.route('/logs')
def getLogEntries():
    form = LogEntryForm()
    return render_template(
        'index.html',
        title='Personal Database',
        form=form
    )

@app.route('/logs/record', methods=['POST'])
def postLogEntry():
    add_input = request.form['add_input']
    try:
        logEntry = LogEntry(text=add_input)
    except Exception:
        return redirect('/error')
    return redirect('/logs')