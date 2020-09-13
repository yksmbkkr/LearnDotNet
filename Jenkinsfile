#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
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
                dotnet build FirstDotNetProject.sln
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh """
                    #!/bin/bash
                    dotnet build-server shutdown
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll begin /k:FirstDotNetProject /d:sonar.host.url=http://35.229.248.239:9000 /d:sonar.cs.opencover.reportsPaths=FirstDotNetProject.FirstDotNetProject/coverage.opencover.xml /d:sonar.coverage.exclusions=”**UnitTest*.cs”
                    dotnet build FirstDotNetProject.sln
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll end 
                    """
                }
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