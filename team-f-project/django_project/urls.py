"""django_project URL Configuration.

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.1/topics/http/urls/

Examples
--------
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))

"""
from django.contrib import admin
from django.urls import path, include
from django.views.generic import TemplateView
from django.contrib.staticfiles.urls import staticfiles_urlpatterns

urlpatterns = [
    path('',
         TemplateView.as_view(template_name="home.html"),
         name="home"),
    path('team',
         TemplateView.as_view(template_name="team.html"),
         name="team"),
    path('about',
         TemplateView.as_view(template_name="about.html"),
         name="about"),
    path('user_analysis',
         TemplateView.as_view(template_name="user_analysis.html"),
         name="user_analysis"),
    path('jason',
         TemplateView.as_view(template_name="jason.html"),
         name="jason"),
    path('selena',
         TemplateView.as_view(template_name="selena.html"),
         name="selena"),
    path('dylan',
         TemplateView.as_view(template_name="dylan.html"),
         name="dylan"),
    path('joel',
         TemplateView.as_view(template_name="joel.html"),
         name="joel"),
    path('preferences',
         TemplateView.as_view(template_name="preferences.html"),
         name="preferences"),
    path('ui_design',
         TemplateView.as_view(template_name="ui_design.html"),
         name="ui_design"),
    path('admin/', admin.site.urls),
    path('accounts/', include('users.urls')),
    path('accounts/', include('django.contrib.auth.urls')),
]

urlpatterns += staticfiles_urlpatterns()
