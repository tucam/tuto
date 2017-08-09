package e4geotools.parts;

import javax.annotation.PostConstruct;
import javax.inject.Inject;

import org.eclipse.e4.core.di.annotations.Optional;
import org.eclipse.e4.ui.di.Focus;
import org.eclipse.e4.ui.di.UIEventTopic;
import org.eclipse.e4.ui.model.application.ui.basic.MPart;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Composite;
import org.geotools.map.MapContent;
import org.geotools.swt.SwtMapPane;
import org.geotools.swt.action.OpenShapefileAction;
import org.osgi.service.event.Event;

public class SamplePart {
	private SwtMapPane mapPane;

	@PostConstruct
	public void createComposite(Composite parent, MPart part) {		
		// create map content
		MapContent mapContent = new MapContent();

		// create map view
		mapPane = new SwtMapPane(parent, SWT.BORDER | SWT.NO_BACKGROUND);
		mapPane.setMapContent(mapContent);
		
		// set the renderer
		// StreamingRenderer renderer = new StreamingRenderer();
		// mapPane.setRenderer(renderer);
	}

	@Focus
	public void setFocus() {
		mapPane.setFocus();
	}

	@Optional
	@Inject
	public void addShpFileToMap(@UIEventTopic("e4geotools/addShpFileEventTopic") Event evt) {		
		OpenShapefileAction openAction = new OpenShapefileAction();
		openAction.setMapPane(mapPane);
		openAction.run();
	}
}