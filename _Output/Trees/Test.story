<?xml version="1.0" encoding="utf-8"?>
<app>
	<meta>
		<name>Test and It's working</name>
		<description>To test the ability to parse the XML File</description>
	</meta>
	<story>
		<template>
			<conseq>Conseqcuences for the Choices</conseq>
			<choice1>
				<btn>choice1 btn context</btn>
				<action>choice1 choosen action</action>
			</choice1>
			<choice2>
				<btn>choice2 btn context</btn>
				<action>choice2 choosen action</action>
			</choice2>
		</template>

		<START>
			<conseq>Which color is yellow?</conseq>
			<choice1>
				<btn>light Yellow</btn>
				<action>a</action>
			</choice1>
			<choice2>
				<btn>Pure Red</btn>
				<action>b</action>
			</choice2>
		</START>
		<a>
			<conseq>You are right. light yellow is a yellow color. Now, Wanna go to next question?</conseq>
			<choice1>
				<btn>ok</btn>
				<action>aba</action>
			</choice1>
			<choice2>
				<btn>ok</btn>
				<action>aba</action>
			</choice2>
		</a>
		<b>
			<conseq>Oh you are wrong and unintelligent. now accept light yellow is yellow</conseq>
			<choice1>
				<btn>Ok</btn>
				<action>aba</action>
			</choice1>
			<choice2>
				<btn>Fine Ok</btn>
				<action>aba</action>
			</choice2>
		</b>
		<aba>
			<conseq>which language is this program written in?</conseq>
			<choice1>
				<btn>C#</btn>
				<action>abaa</action>
			</choice1>
			<choice2>
				<btn>C++</btn>
				<action>abab</action>
			</choice2>
		</aba>
		<abaa>
			<conseq>Correct. Wanna play this again?</conseq>
			<choice1>
				<btn>Yeh. Why not</btn>
				<action>START</action>
			</choice1>
			<choice2>
				<btn>No. Get lost</btn>
				<action>END</action>
			</choice2>
		</abaa>
		<abab>
			<conseq>Wrong. This program is written with .NET Framework 4.8 in C#. So, Play this game again?</conseq>
			<choice1>
				<btn>No. This is Dumb</btn>
				<action>END</action>
			</choice1>
			<choice2>
				<btn>once again</btn>
				<action>START</action>
			</choice2>
		</abab>
	</story>
</app>