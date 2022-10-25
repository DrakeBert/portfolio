# Project Title

Basic Tutorial for teamwork through GitLab using Django and Python.

**Insert project description here**

This project demonstrates how a team lead is responsible keeping track of what the team is doing by assigning certain issues to each member,
as well as each member learning how to work through these issues using GitLab. 

The project is deployed on Heroku: [https://sp22-team-f.herokuapp.com](https://sp22-team-f.herokuapp.com)

The template project is deployed on Heroku: [https://cmps-453-project-template.herokuapp.com/](https://cmps-453-project-template.herokuapp.com/)

To develop this Django application, clone this repository and follow the instructions:

## What's Already Included in the Django Template?
* User Authentication System:
    * Login: [https://cmps-453-project-template.herokuapp.com/accounts/login/](https://cmps-453-project-template.herokuapp.com/accounts/login/)
    * User Registration: [https://cmps-453-project-template.herokuapp.com/accounts/signup/](https://cmps-453-project-template.herokuapp.com/accounts/signup/)

## Install Python Requirements

```bash
pip install -r requirements.txt
```

## Apply Migrations

```bash
python manage.py migrate
```

## Collect Static Files

```bash
python manage.py collectstatic --no-input
```

## Run the Django Web Server

```bash
python manage.py runserver
```

## Team Members
**Update the last name, first name, Heroku app name, and URLs in the table below **

| Role | Last Name | First Name | Heroku App |
| ---- | --------- |  --------- | -----------|
| Member A | Bertrand | Drake  | [sp22-team-f-a.herokuapp.com](update URL here) |
| Member B | Herbert  | Ryan   | [sp22-team-f-b.herokuapp.com](update URL here) |
| Member C | Johnson  | Dylan  | [sp22-team-f-c.herokuapp.com](update URL here) |
| Member D | Defelice | Luke   | [sp22-team-f-d.herokuapp.com](update URL here) |

## Set up GitLab CD
See the [DEPLOY.md](DEPLOY.md)
