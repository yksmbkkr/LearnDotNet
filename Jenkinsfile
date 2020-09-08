#!groovy
pipeline {
    agent {
        docker {
            image 'yksmbkkr/jdk-dotnetcoresdk:1.0'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                dotnet build
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet build
                """
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                dotnet run --project FirstDotNetProject
                """
            }
        }
    }
    post {
        always {
            emailext body: '$DEFAULT_CONTENT', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: '$DEFAULT_SUBJECT', replyTo: '$DEFAULT_REPLYTO'
        }
    }
}