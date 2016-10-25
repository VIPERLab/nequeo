/* ChildFrame.cpp:

   Copyright (C) 1996-2016 Christian Schenk

   This file is part of Yap.

   Yap is free software; you can redistribute it and/or modify it
   under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2, or (at your option)
   any later version.

   Yap is distributed in the hope that it will be useful, but WITHOUT
   ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
   or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public
   License for more details.

   You should have received a copy of the GNU General Public License
   along with Yap; if not, write to the Free Software Foundation, 59
   Temple Place - Suite 330, Boston, MA 02111-1307, USA. */

#include "StdAfx.h"

#include "yap.h"

#include "ChildFrame.h"

IMPLEMENT_DYNCREATE(ChildFrame, CMDIChildWnd);

BEGIN_MESSAGE_MAP(ChildFrame, CMDIChildWnd)
END_MESSAGE_MAP();

BOOL ChildFrame::PreCreateWindow(CREATESTRUCT & cs)
{
  cs.style = (0
    | FWS_ADDTOTITLE
    | WS_CAPTION
    | WS_CHILD
    | WS_MAXIMIZE
    | WS_MAXIMIZEBOX
    | WS_MINIMIZEBOX
    | WS_OVERLAPPED
    | WS_SYSMENU
    | WS_THICKFRAME
    | WS_VISIBLE
    );
  return CMDIChildWnd::PreCreateWindow(cs);
}