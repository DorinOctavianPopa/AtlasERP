# AtlasERP User Interface Guide

## Application Flow

```
┌─────────────────────────────────────────────────────────────┐
│                     Login Page                               │
│  ┌───────────────────────────────────────────────────────┐  │
│  │              AtlasERP                                  │  │
│  │   Enterprise Resource Planning                        │  │
│  │                                                        │  │
│  │  ┌────────────────────────────────────────────────┐  │  │
│  │  │  Username: [____________________]              │  │  │
│  │  │  Password: [____________________]              │  │  │
│  │  │                                                 │  │  │
│  │  │         [     Sign In     ]                    │  │  │
│  │  │                                                 │  │  │
│  │  │  Demo: Use any username/password               │  │  │
│  │  │  Use 'admin' for admin role                    │  │  │
│  │  └────────────────────────────────────────────────┘  │  │
│  └───────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
                            │
                            │ After Login
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                      Main Page                               │
│  ┌──────────┬──────────────────────────────────────────────┐│
│  │          │                                               ││
│  │ AtlasERP │  Welcome to AtlasERP                          ││
│  │          │                                               ││
│  │ Welcome, │  Select a module or management option         ││
│  │ User!    │  from the menu to get started                 ││
│  │          │                                               ││
│  │──────────│  ┌────────────┬────────────┬────────────┐    ││
│  │          │  │ 👥         │ ⚙️         │ 🏢         │    ││
│  │ 📊 Dash  │  │ Active     │ Active     │ Organiza-  │    ││
│  │ board    │  │ Users      │ Modules    │ tions      │    ││
│  │          │  │ 24         │ 4          │ 3          │    ││
│  │ 👥 User  │  └────────────┴────────────┴────────────┘    ││
│  │ Mgmt     │                                               ││
│  │          │                                               ││
│  │ 🏢 Org   │                                               ││
│  │ Mgmt     │                                               ││
│  │          │                                               ││
│  │ ⚙️ Module│                                               ││
│  │ Mgmt     │                                               ││
│  │          │                                               ││
│  │ 📦 Inven │                                               ││
│  │ tory     │                                               ││
│  │          │                                               ││
│  │ 💰 Sales │                                               ││
│  │          │                                               ││
│  │ 📊 Acct  │                                               ││
│  │          │                                               ││
│  │ 👥 HR    │                                               ││
│  │          │                                               ││
│  │ [Logout] │                                               ││
│  └──────────┴───────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

## Page Descriptions

### 1. Login Page
**Purpose**: User authentication

**Features**:
- Username input field
- Password input field (masked)
- Sign In button
- Loading indicator during authentication
- Error message display
- Demo mode information

**Demo Credentials**:
- Username: Any (try "admin" for admin role)
- Password: Any

### 2. Main Page (Dashboard Shell)
**Purpose**: Central navigation hub

**Layout**:
- **Left Sidebar** (250px):
  - AtlasERP branding
  - Welcome message
  - Navigation menu items
  - Logout button

- **Main Content Area**:
  - Welcome message
  - Quick statistics cards
  - Content from selected page

**Navigation Menu**:
- 📊 Dashboard
- 👥 User Management
- 🏢 Organization Management
- ⚙️ Module Management
- 📦 Inventory (module)
- 💰 Sales (module)
- 📊 Accounting (module)
- 👥 HR (module)

### 3. Dashboard Page
**Purpose**: Business overview

**Content**:
- Page title and description
- 4 metric cards in 2x2 grid:
  - Sales Overview ($125,430)
  - Inventory Status (842 items)
  - Active Employees (156)
  - Pending Transactions (38)

### 4. User Management Page
**Purpose**: Manage system users

**Features**:
- Add User button
- User list in table format
- Columns: Username, Name, Email, Role
- Edit and Delete buttons for each user
- Sample data included

**Actions**:
- ➕ Add new user
- ✏️ Edit existing user
- 🗑️ Delete user

### 5. Organization Management Page
**Purpose**: Manage organizations

**Features**:
- Add Organization button
- Organization cards with:
  - Name and description
  - Contact information (email, phone, address)
  - Status badge (Active/Inactive)
  - Enabled modules count
  - Edit and Delete buttons

**Sample Data**:
- Atlas Corporation (4 modules)
- Beta Industries (2 modules)

### 6. Module Management Page
**Purpose**: Configure system modules

**Features**:
- Module cards in grid layout
- Each card shows:
  - Module icon (emoji)
  - Name and description
  - Enable/Disable switch
  - Status badge
  - Module ID
  - Configure button

**Modules**:
- 📦 Inventory
- 💰 Sales
- 📊 Accounting
- 👥 Human Resources

## UI Theme Support

### Light Theme
- Background: White
- Text: Dark gray (#212121)
- Primary: Purple (#512BD4)
- Borders: Light gray (#E1E1E1)

### Dark Theme
- Background: Black
- Text: White
- Primary: Purple (#512BD4)
- Borders: Dark gray (#404040)

Theme switches automatically based on system preferences.

## Navigation Patterns

### Primary Navigation
Use the sidebar menu to navigate between main pages.

### Hover Effects
Menu items highlight on hover:
- Light theme: Light gray background
- Dark theme: Dark gray background

### Active State
Currently selected page is indicated (implementation pending).

### Modal Dialogs
For add/edit operations (to be implemented):
- User add/edit dialog
- Organization add/edit dialog
- Module configuration dialog

## Responsive Design

### Desktop (1920x1080+)
- Full sidebar (250px)
- Wide content area
- Grid layouts for cards

### Tablet (768x1024)
- Collapsible sidebar
- Stacked cards
- Touch-friendly buttons

### Mobile (375x667)
- Hidden sidebar with menu button
- Single column layout
- Optimized for touch

## Color Palette

### Primary Colors
- Primary: #512BD4 (Purple)
- Secondary: #DFD8F7 (Light purple)
- Tertiary: #2B0B98 (Dark purple)

### Status Colors
- Success: #4CAF50 (Green)
- Warning: #FF9800 (Orange)
- Error: #F44336 (Red)
- Info: #2196F3 (Blue)

### Neutral Colors
- White: #FFFFFF
- Black: #000000
- Gray shades: #E1E1E1 to #212121

## Accessibility

### Keyboard Navigation
- Tab through form fields
- Enter to submit forms
- Arrow keys for lists (planned)

### Screen Readers
- Semantic XAML elements
- Descriptive labels
- ARIA-like attributes (MAUI AutomationProperties)

### Color Contrast
- WCAG 2.1 AA compliant
- High contrast mode support
- Clear focus indicators

## User Experience Principles

1. **Consistency**: Uniform design across all pages
2. **Clarity**: Clear labels and intuitive layout
3. **Feedback**: Loading indicators and error messages
4. **Efficiency**: Quick access to common tasks
5. **Simplicity**: Clean, uncluttered interface

## Icons and Emojis

Using emoji icons for visual clarity:
- 📊 Dashboard / Analytics
- 👥 Users / HR
- 🏢 Organizations
- ⚙️ Settings / Modules
- 📦 Inventory
- 💰 Sales / Money
- ✏️ Edit
- 🗑️ Delete
- ➕ Add

## Future UI Enhancements

- [ ] Add breadcrumb navigation
- [ ] Implement advanced search
- [ ] Add data visualization charts
- [ ] Create notification system
- [ ] Add keyboard shortcuts
- [ ] Implement drag-and-drop
- [ ] Add animation transitions
- [ ] Create mobile-optimized layouts
- [ ] Add customizable dashboard widgets
- [ ] Implement real-time updates
