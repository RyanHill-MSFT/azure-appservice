from app import app, db

@app.route('/')
@app.route('/error')
def index():
    form = f.PersonalLogForm()
    return render_template(
        'index.html',
        title='Personal Database',
        form=form
    )
