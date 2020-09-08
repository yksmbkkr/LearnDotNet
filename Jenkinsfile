#!groovy
pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/core/sdk:3.1'
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
                ls
                cd FirstDotNetProject
                ls
                dotnet build
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                cd FirstDotNetProject
                dotnet build
                """
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                cd FirstDotNetProject
                dotnet run
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