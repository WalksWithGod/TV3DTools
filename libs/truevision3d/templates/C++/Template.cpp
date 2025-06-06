// Template.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Template.h"

#include "CTVEngine.h"
#include "CTVScene.h"
#include "CTVInputEngine.h"
#include "tv_types.h"

#define MAX_LOADSTRING 100

// TV3D Variables:
CTVEngine* pTV;
CTVScene* pScene;
CTVInputEngine* pInput;
HWND formHWND;
bool bDoLoop;

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);

void AppPath(char* PathOfFile, char* ret_Path)
{							
	char* found = strrchr(PathOfFile, '\\');
	if(!found)
	{
		// check with '/' path format
		found = strrchr(PathOfFile, '/');
		if(!found)
		{
			// no path herre it's just a file.
			// so just blank output
			ret_Path[0] = 0;
		}
		else
		{
			// copy just a part of the string
			int size = (int)found - (int)PathOfFile + 1;
			strncpy(ret_Path, PathOfFile, size);
			ret_Path[size] = 0;
		}

	}
	else
	{
		// copy just a part of the string
		int size = (int)found - (int)PathOfFile + 1;
		strncpy(ret_Path, PathOfFile, size);
		ret_Path[size] = 0;
	}		
}

void InitTV3D()
{
	// Create the pTV Interface first:
	pTV = new CTVEngine();

	// Set the debug file/options.
	// Do this before the 3D init so it can log any errors found during init.
	char path[256];
	char srchpath[256];
	
	GetModuleFileName(NULL,path,255); 

	AppPath(path,srchpath);	
	
	pTV->SetDebugMode(true, true);
	pTV->SetDebugFile(strcat(srchpath, "\\debugfile.txt"));

	// Set your beta-key/license:
	// pTV->SetLicenseKey(TV_LICENSE_COMMERCIAL, "username", "key");
	pTV->SetBetaKey("", "");

	// After setting the beta-key/license its time to init the engine:
	pTV->Init3DWindowed(formHWND, true);

	// Something good to do is to enable the auto-resize feature:
	// Get the default viewport and set autoresize to true for it:
	pTV->GetViewport()->SetAutoResize(true);

	// Lets display the FPS:
	pTV->DisplayFPS(true);

	// Set the prefered angle system:
	pTV->SetAngleSystem(cTV_ANGLE_DEGREE);

	// Now after we are done initializing the TVEngine component lets continue:
	// Create any other components after pTV init->

	pScene = new CTVScene();
	
	// Input has an additional init method to call->
	pInput = new CTVInputEngine();
	// Lets init both keyboard and mouse:
	pInput->Initialize(true, true);
	

	// Now we have setup the most basic of components->
	// Something to think about, if the component has a diffrent ATL init method
	// then the Object = new pTV<NAME>, use that one instead->

	// For example:
	// CTVMesh* Mesh;
	// Mesh = Scene->CreateMeshBuilder("MyMesh"); <- Instead of Mesh = new CTVMesh();
	// Same goes for RenderSurface, Viewport etc->
	
	// Setup the boolean for the loop.
	bDoLoop = true;
}

// A method for Processing Mesages that will be used in the loop.


int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_TEMPLATE, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow)) 
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, (LPCTSTR)IDC_TEMPLATE);

	// Call our Init TV3D method.
	InitTV3D();

	// Main message loop:
	while (bDoLoop) 
	{
		// Render Loop
		if(GetFocus() == formHWND)
		{
			pTV->Clear(false);
				// Render Everything
				pScene->RenderAll(true);
			pTV->RenderToScreen();
			
			// If the ESC key is pressed stop the application.
			if(pInput->IsKeyPressed(cTV_KEY_ESCAPE)) { SendMessage(formHWND, WM_DESTROY, 0, 0); }
		} else {
			// So we dont process the messages to many times if we are not rendering.
			Sleep(100);
		}
		
		BOOL peek = PeekMessage(&msg, NULL, 0, 0, TRUE);

		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg)) 
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}


//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX); 

	wcex.style			= 0;
	wcex.lpfnWndProc	= (WNDPROC)WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, (LPCTSTR)IDI_TEMPLATE);
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= NULL;
	wcex.lpszMenuName	= NULL;
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, (LPCTSTR)IDI_SMALL);

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HANDLE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, 640, 480, NULL, NULL, hInstance, NULL);
	
   // Store the Created Window's hWnd in a glboal HWND variable.
   formHWND = hWnd;

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, unsigned, WORD, LONG)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message) 
	{
	case WM_DESTROY:
		// Stop the loop.
		bDoLoop = false;

		// Free TV:
		delete(pTV);
		pTV = NULL;		
		

		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}
