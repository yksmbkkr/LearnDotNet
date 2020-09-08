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
                cd FirstDotNetProject
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
            emailext body: $PROJECT_NAME+' - Build # '+$BUILD_NUMBER+' - '+$BUILD_STATUS+': \n Check console output at '+$BUILD_URL+' to view the results.', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: $PROJECT_NAME +'- Build # '+$BUILD_NUMBER+' - '+$BUILD_STATUS+'!'
        }
    }
}